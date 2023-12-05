import chalk from 'chalk'
import figlet from 'figlet'
import inquirer from 'inquirer'
import ora from 'ora';

const welcomeMessage = (message) => {
  console.clear()

  console.log(
    chalk.yellow(
      figlet.textSync('Igor Bank', {
        font: 'ANSI Shadow',
        horizontalLayout: 'default',
        verticalLayout: 'default'
      })
    )
  )

  if (message && typeof message === 'string') {
    console.log(chalk.green(message))
  }
}

const askUserQuestions = async () => {
  const questions = [
    {
      name: 'email',
      type: 'input',
      message: 'Digite seu e-mail:',
      validate: (email) => {
        const isValid = email.match(
          /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/
        )

        if (isValid) return true

        return 'Por favor, digite um e-mail válido'
      }
    },
    {
      name: 'password',
      type: 'password',
      message: 'Digite sua senha:',
      validate: (password) => {
        if (password.length < 6) {
          return 'A senha deve ter no mínimo 6 caracteres'
        }

        return true
      }
    },
    {
      name: 'name',
      type: 'input',
      message: 'Digite seu nome de usuário:',
      validate: (username) => {
        if (username.length < 3) {
          return 'O nome de usuário deve ter no mínimo 3 caracteres'
        }

        if (username.length > 20) {
          return 'O nome de usuário deve ter no máximo 20 caracteres'
        }

        return true
      }
    },
  ]
  return await inquirer.prompt(questions)
}

const askBankOptions = async () => {
  const questions = [
    {
      name: 'option',
      type: 'list',
      message: 'Escolha a opção desejada:',
      choices: [
        'Depositar',
        'Sacar',
        'Extrato',
        'Sair'
      ]
    }
  ]
  return await inquirer.prompt(questions)

}

const askDepositValue = async () => {
  const questions = [
    {
      name: 'depositValue',
      type: 'input',
      message: 'Digite o valor do depósito:',
      validate: (value) => {
        if (isNaN(value)) {
          return 'Digite um valor válido'
        }

        return true
      }
    }
  ]
  return await inquirer.prompt(questions)

}

const askWithdrawValue = async () => {
  const questions = [
    {
      name: 'withdrawValue',
      type: 'input',
      message: 'Digite o valor do saque:',
      validate: (value) => {
        if (isNaN(value)) {
          return 'Digite um valor válido'
        }

        return true
      }
    }
  ]
  return await inquirer.prompt(questions)
}

const addBankStatement = (user, type, value) => {
  user.bankStatement.push({
    type,
    value,
    currencyValue: value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }),
    date: new Date()
  })
  user.currencyBalance = user.balance.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })
}

const initLoading = (loadingMessage = 'Carregando...', loadingTime = 2000) => {
  return new Promise((resolve) => {
    const spinner = ora(loadingMessage).start();

    setTimeout(() => {
      spinner.stop();
      resolve();
    }, loadingTime);
  });
}

(async () => {
  try {
    welcomeMessage('Crie sua conta !')
    const createdUser = await askUserQuestions()
    await initLoading('Criando sua conta...')

    const user = {
      ...createdUser,
      balance: 0,
      currencyBalance: 'R$ 0,00',
      bankStatement: [],
    } 
    
    let leaveSystem = false
    do {
      welcomeMessage(`Seja bem vindo(a) ${user.name}!\nSaldo Atual: ${user.currencyBalance}`)
      const { option } = await askBankOptions()
      await initLoading('Carregando...', 1000)
      let loadingTime = 1000

      switch (option) {
        case 'Depositar':
          const { depositValue } = await askDepositValue()

          user.balance += Number(depositValue)
          addBankStatement(user, 'Depósito', Number(depositValue))
          break
        case 'Sacar':
          const { withdrawValue } = await askWithdrawValue()

          if (user.balance < Number(withdrawValue)) {
            console.log(chalk.red('Saldo insuficiente'))
          } else {
            user.balance -= Number(withdrawValue)
            addBankStatement(user, 'Saque', Number(withdrawValue))
          }
          break
        case 'Extrato':
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
        case 'Sair':
          console.log(chalk.green('Obrigado por utilizar o Igor Bank!'))
          leaveSystem = true
          break
        default:
          console.log(chalk.red('Opção inválida, tente novamente.'))
          break
      }

      await initLoading('Carregando...', loadingTime)
    } while (!leaveSystem)
  } catch (error) {
    console.log(chalk.red('Ocorreu um erro inesperado, tente novamente mais tarde.', error))
  }
})()