import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloFromVux'

Vue.use(Router)

Router.prototype.goBack = function () {
  this.isBack = true;
  window.history.go(-1);
}

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/documents',
      component: function (reslove) {
        require(['../views/document/Index'], reslove);
      },
      meta: {
        title:'帮助文档'
      }
    },
    {
      path: '/docDetails/:id',
      component: function (reslove) {
        require(['../views/document/Details'], reslove);
      },
      meta: {
        title: '帮助文档'
      }
    },
    {
      path: '/docDetailsByIndexType/:documentIndexType',
      component: function (reslove) {
        require(['../views/document/Details'], reslove);
      },
      meta: {
        title: '帮助文档'
      }
    },
  ]
})
