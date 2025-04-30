import axios, { AxiosHeaders, type AxiosResponse, type InternalAxiosRequestConfig } from 'axios'

import type { HttpResponse } from './response'

axios.defaults.baseURL = 'http://localhost:2345/api'

axios.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    return config
  },
  (error) => {
    return Promise.reject(error)
  },
)

axios.interceptors.response.use(
  (response: AxiosResponse<HttpResponse>) => {
    const { message } = response.data
    return { ...response }
  },
  (error) => {
    if (error) {
      return Promise.reject()
    }

    return Promise.reject()
  },
)
