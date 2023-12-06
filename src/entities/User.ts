import { UserType } from '../types/User.ts'

export class User {
  #user: UserType

  constructor(user: UserType) {
    this.#user = user
  }

  get name() {
    return this.#user.name
  }

  get currencyBalance() {
    return this.#user.currencyBalance
  }

  get bankStatement() {
    return this.#user.bankStatement
  }

  get balance() {
    return this.#user.balance
  }

  set balance(value: number) {
    this.#user.balance = value
  }

  addBankStatement = (type: string, value: number, balance: number) => {
    this.#user.bankStatement.push({
      type,
      value,
      currencyValue: value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }),
      date: new Date()
    })
    this.#user.currencyBalance = balance.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })
  }
}