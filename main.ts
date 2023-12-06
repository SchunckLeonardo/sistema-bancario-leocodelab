import chalk from 'npm:chalk@5.3.0'

import { UserType } from './src/types/User.ts'
import { Screen } from './src/entities/Screen.ts'
import { User } from './src/entities/User.ts'

(async () => {
  const {
    welcomeMessage,
    askUserQuestions,
    askBankOptions,
    askDepositValue,
    askWithdrawValue,
    initLoading
  } = new Screen()

  try {
    welcomeMessage('Crie sua conta !')

    const userAnswers = await askUserQuestions()
    const userData: UserType = {
      ...userAnswers,
      balance: 0,
      currencyBalance: 'R$ 0,00',
      bankStatement: [],
    }
    const user = new User(userData)
    await initLoading('Criando sua conta...')
    
    let leaveSystem = false
    do {
      welcomeMessage(`Seja bem vindo(a) ${user.name}!\nSaldo Atual: ${user.currencyBalance}`)

      const { option } = await askBankOptions()
      await initLoading('Carregando...', 1000)
      let loadingTime = 1000

      switch (option) {
        case 'Depositar': {
          const { depositValue } = await askDepositValue()

          user.balance += Number(depositValue)
          user.addBankStatement('Depósito', Number(depositValue), user.balance)
          break
        }
        case 'Sacar': {
          const { withdrawValue } = await askWithdrawValue()

          if (user.balance < Number(withdrawValue)) {
            console.log(chalk.red('Saldo insuficiente'))
          } else {
            user.balance -= Number(withdrawValue)
            user.addBankStatement('Saque', Number(withdrawValue), user.balance)
          }
          break
        }
        case 'Extrato': {
          console.log(chalk.green('Extrato bancário'))
          user.bankStatement.forEach(({ type, currencyValue, date }) => {
            if (type === 'Saque') {
              console.log(chalk.red(`${type} - ${currencyValue} - ${date.toLocaleString('pt-BR')}`))
              return
            }

            console.log(chalk.green(`${type} - ${currencyValue} - ${date.toLocaleString('pt-BR')}`))
          })
          loadingTime = 6000
          break
        }
        case 'Sair': {
          console.log(chalk.green('Obrigado por utilizar o Igor Bank!'))
          leaveSystem = true
          break
        }
        default: {
          console.log(chalk.red('Opção inválida, tente novamente.'))
          break
        }
      }

      await initLoading('Carregando...', loadingTime)
    } while (!leaveSystem)
  } catch (error) {
    console.log(chalk.red('Ocorreu um erro inesperado, tente novamente mais tarde.', error))
  }
})()