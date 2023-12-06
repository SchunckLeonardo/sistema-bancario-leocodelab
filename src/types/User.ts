import { BankStatement } from './BankStatement.ts'

export interface UserType {
  email: string
  password: string
  name: string
  balance: number
  currencyBalance: string
  bankStatement: BankStatement[]
}