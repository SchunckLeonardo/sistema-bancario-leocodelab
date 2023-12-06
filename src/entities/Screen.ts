import chalk from 'npm:chalk@5.3.0'
import figlet from 'npm:figlet@1.7.0'
import inquirer from 'npm:inquirer@9.2.12'
import ora from 'npm:ora@7.0.1'

import { title } from "../constants/title.ts"
import { choices } from "../constants/choices.ts"

export class Screen {
  welcomeMessage = (message: string) => {
    console.clear()
  
    console.log(
      chalk.yellow(
        figlet.textSync(title.name, title.style)
      )
    )
  
    if (message) {
      console.log(chalk.green(message))
    }
  }
  
  askUserQuestions = async () => {
    const questions = [
      {
        name: 'email',
        type: 'input',
        message: 'Digite seu e-mail:',
        validate: (email: string) => {
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
        validate: (password: string) => {
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
        validate: (username: string) => {
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
  
  askBankOptions = async () => {
    const questions = [
      {
        name: 'option',
        type: 'list',
        message: 'Escolha a opção desejada:',
        choices: choices.map(choice => choice.name)
      }
    ]
    return await inquirer.prompt(questions)
  
  }
  
  askDepositValue = async () => {
    const questions = [
      {
        name: 'depositValue',
        type: 'input',
        message: 'Digite o valor do depósito:',
        validate: (value: string) => {
          if (isNaN(parseFloat(value))) {
            return 'Digite um valor válido'
          }
  
          return true
        }
      }
    ]
    return await inquirer.prompt(questions)
  
  }
  
  askWithdrawValue = async () => {
    const questions = [
      {
        name: 'withdrawValue',
        type: 'input',
        message: 'Digite o valor do saque:',
         validate: (value: string) => {
          if (isNaN(parseFloat(value))) {
            return 'Digite um valor válido'
          }
  
          return true
        }
      }
    ]
    return await inquirer.prompt(questions)
  }

  initLoading = (loadingMessage = 'Carregando...', loadingTime = 2000) => {
    return new Promise<void>((resolve) => {
      const spinner = ora(loadingMessage).start()
  
      setTimeout(() => {
        spinner.stop()
        resolve()
      }, loadingTime)
    })
  }
}