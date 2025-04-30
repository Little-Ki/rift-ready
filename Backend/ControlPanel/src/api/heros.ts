import axios from 'axios'
import type { HttpResponse } from './response'

export interface Hero {
  alias: string
  attack: string
  heroId: string
  keywords: string
  magic: string
  name: string
  title: string
}

export interface HeroSpell {
  heroId: string
  name: string
  description: string
  spellKey: string
  cooldown: string
  cost: string
  range: string
  abilityIconPath: string
}

export interface HeroSkin {
  skinId: string
  loadingImg: string
  name: string
}

export interface HeroInfo {
  fileName: string
  fileTime: string
  version: string
  hero: Hero
  skins: HeroSkin[]
  spells: HeroSpell[]
}

export function list(keyword?: string, id?: string) {
  return axios.get<HttpResponse<Array<Hero>>>('/heros', { params: { keyword, id } })
}

export function query(heroId: string) {
  return axios.get<HeroInfo>(`images/lol/act/img/js/hero/${heroId}.js`, { baseURL: "https://game.gtimg.cn" })
}