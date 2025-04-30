<template>
    <div class="view-content">
        <title-view value="英雄信息" :buttons="['plus']" @button="showPicker">
        </title-view>
        <div class="hero-content" v-if="heroInfo">
            <swiper width="200px" aspect="180%">
                <swiper-item v-if="heroInfo && heroInfo.skins.length > 0" v-for="(it, index) of heroInfo.skins">
                    <div class="hero-img-wrapper">
                        <img :src="it.loadingImg" class="hero-img" />
                    </div>
                </swiper-item>
            </swiper>

            <div class="hero-details" style="width: calc(100% - 220px);">
                <div class="hero-name">
                    <div style="font-size: 1.2rem; font-weight: bold;">{{ heroInfo.hero.name }}</div>
                    &nbsp;-&nbsp;
                    <div style="font-size: 1.1rem;">{{ heroInfo.hero.title }}</div>
                </div>
                <div class="hero-spells">
                    <div v-for="(it, index) of ['passive', 'q', 'w', 'e', 'r']" :key="index" class="spell-icon" :class="{
                        select: spell.spellKey === it
                    }" @click="() => switchSpell(it)!">
                        <img :src="findSpell(it).abilityIconPath" />
                    </div>
                </div>

                <div class="spell-name">
                    {{
                        {
                            'passive': '被动',
                            'q': 'Q',
                            'w': 'W',
                            'e': 'E',
                            'r': 'R'
                        }[spell.spellKey]
                    }}
                    -
                    {{ spell.name }}
                </div>

                <div class="spell-info">
                    冷却：{{ spell.cooldown.length > 0 ? spell.cooldown : '无' }}
                </div>
                <div class="spell-info">
                    消耗：{{ spell.cost.length > 0 ? spell.cost : '无' }}
                </div>
                <div class="spell-info">
                    范围：{{ spell.range.length > 0 ? spell.range : '无' }}
                </div>
                <div class="spell-info">
                    {{ spell.description }}
                </div>
            </div>
        </div>
        <champ-pick @pick="selectHero" ref="refPicker" />
    </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import Api from '@/api';
import type { Hero, HeroInfo, HeroSpell } from '@/api/heros';


import TitleView from '@/components/TitleView.vue';
import ChampPick from '@/components/ChampPick.vue';
import Swiper from '@/components/swiper/Swiper.vue';
import SwiperItem from '@/components/swiper/SwiperItem.vue';

const refPicker = ref();

const showPicker = () => refPicker.value.show()

const heroInfo = ref(null as unknown as HeroInfo)

const spell = ref(null as unknown as HeroSpell)

const selectHero = (hero: Hero) => {
    Api.heros.query(hero.heroId).then(({ data }) => {
        heroInfo.value = data
        heroInfo.value.skins = heroInfo.value.skins.filter(x => x.loadingImg.length > 0)
        switchSpell('passive')!
    })
}

const switchSpell = (spellKey: string) => {
    spell.value = findSpell(spellKey)!
}

const findSpell = (spellKey: string) => {
    return heroInfo.value.spells.find(x => x.spellKey == spellKey)!
}

</script>

<style lang="less" scoped>
.hero-content {
    width: 100%;
    height: calc(100% - 40px);
    display: flex;
    justify-content: space-between;
}

.hero-img-wrapper {
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;

    .hero-img {
        max-height: 100%;
        max-width: 100%;
    }
}

.hero-details {
    display: flex;
    flex-direction: column;

    .hero-name {
        display: flex;
        align-items: center;
    }

    .hero-spells {
        display: flex;
        margin-top: 1.5rem;

        .spell-icon {
            width: 4rem;
            height: 4rem;
            border: 1px solid #e0e0e0;
            border-radius: 0.5rem;
            overflow: hidden;
            margin-right: 1rem;
            transition: all 0.25s ease;

            >img {
                width: 100%;
                height: 100%;
            }
        }

        .spell-icon.select {
            border: 1px solid transparent;
            filter: drop-shadow(0 0 0.5rem rgb(56, 105, 240));
        }
    }

    .spell-name {
        margin-top: 1.5rem;
    }
}
</style>