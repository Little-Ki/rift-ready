import axios from 'axios'
import type { HttpResponse } from './response'

export interface GameStatus {
  isOpen: boolean
  currentScene: string
  statusText: string
}

export function get() {
  return axios.get<HttpResponse<GameStatus>>('/status')
}
