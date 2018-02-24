// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import $ from 'jquery' // jq
window.$ = window.jquery = window.jQuery = jQuery = $;

import Vue from 'vue'
import Vuex from 'vuex'
import FastClick from 'fastclick'
import VueRouter from 'vue-router'
import App from './App'

Vue.use(Vuex);
Vue.use(VueRouter)
Vue.use(require('vue-wechat-title'));

import Config from './common/config'
import LoadFile from './common/utils/loadFile'
console.log(Config.apiHost, process.env);

import './vendor/abp/scripts/abp.js'
import './vendor/abp/scripts/libs/abp.jquery.js'

let router = require('./router').default;

FastClick.attach(document.body)

Vue.config.productionTip = false


// 加载apb的ajax库
LoadFile.loadJs('/api/AbpServiceProxies/GetAll?type=jquery').then(() => {
  /* eslint-disable no-new */

  abp.router = router;
  const store = new Vuex.Store({}) // 这里你可能已经有其他 module

  store.registerModule('vux',
    { // 名字自己定义
      state: {
        isLoading: false
      },
      mutations: {
        updateLoadingStatus(state, payload) {
          state.isLoading = payload.isLoading;
        }
      }
    });


  router.beforeEach(function (to, from, next) {
    store.commit('updateLoadingStatus', { isLoading: true });
    next()
  })

  router.afterEach(function (to) {
    store.commit('updateLoadingStatus', { isLoading: false });
  })

  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app-box')

}).catch(() => {
  abp.message.error('加载失败,请刷新后重试')
})
