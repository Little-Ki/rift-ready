import axios from 'axios'
import type { HttpResponse } from './response'

export interface Config {
  autoBan: {
    enable: boolean;
    championIds: number[];
  };
  autoPick: {
    enable: boolean;
    championIds: number[];
  };
  feature: {
    autoAcceptMM: boolean
  }
}

export function get() {
  return axios.get<HttpResponse<Config>>('/config')
}

export function set(value: Config) {
  return axios.post<HttpResponse<Config>>('/config', value)
}