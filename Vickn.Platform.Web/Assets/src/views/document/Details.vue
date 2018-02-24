<template>
  <div>
    <div>
    </div>
    <card>
      <!--<div slot="header" style="padding-top:5px">
        <h3 style="text-align:center">{{document.title}}</h3>
        <divider>---</divider>
      </div>-->
      <div slot="content" class="card-padding">
        <div class="content">
          <p v-html="document.content"></p>
        </div>
      </div>
    </card>
    <!--<group v-if="document.document2Documents &&document.document2Documents.length>0 " title="您可能还需要：">
      <cell v-for="(item,index) in document.document2Documents" :key="item.nextDocument.id" :title="item.nextDocument.title" :link="'/docDetails/'+item.nextDocument.id"></cell>
    </group>-->
    <br />
  </div>
</template>
<script>
  import { Card, XHeader, Divider, Group, Cell } from 'vux'
  import documentService from '../../services/document/documentService'
  export default {
    components: {
      Card,
      XHeader,
      Divider, Group, Cell
    },
    data() {
      return {
        document: {},
      }
    },
    watch: {
      '$route': function () {
        window.scrollTo(0, 0);
        this.fetchData()
      }
    },
    created() {
      this.fetchData()
    },
    methods: {
      async fetchData() {
        let input = {
          id: this.$route.params.id,
        };
        let ret = await documentService.getByIdAsync(input)
        this.document = ret
        document.title = this.document.title
      }
    }
  }
</script>

<style lang="less" scoped>
  .center-nopadding {
    text-align: center;
    color: #fff;
    font-size: 18px;
  }

  .center {
    padding-top: 20px;
    text-align: center;
    color: #fff;
    font-size: 18px;
  }

  .card-padding {
    padding: 10px 15px 15px 15px;
  }

  .center img {
    width: 100px;
    height: 100px;
    border-radius: 50%;
    border: 4px solid #ececec;
  }

  .tx {
    width: 50px;
    height: 50px;
    border-radius: 50%;
  }

  img.img-button {
    width: 20px;
    height: 20px;
  }

  .right {
    background-color: transparent;
    position: absolute;
    right: 0px;
    margin-right: 10px;
    height: 30px;
  }

  .menu-img {
    position: absolute;
    margin-left: 10px;
    top: 15px;
    border-radius: 3px;
    cursor: pointer;
  }

  .menu-txt {
    margin: 15px 15px 15px 75px;
  }

  .box2-wrap {
    height: 300px;
    overflow: hidden;
  }

  .rotate {
    display: inline-block;
    transform: rotate(-180deg);
  }

  .pullup-arrow {
    transition: all linear 0.2s;
    color: #666;
    /*font-size: 25px;*/
  }
</style>

<style lang="less" scoped>
  .box2-wrap {
    height: 300px;
    overflow: hidden;
  }

  .rotate {
    display: inline-block;
    transform: rotate(-180deg);
  }

  .pullup-arrow {
    transition: all linear 0.2s;
    color: #666;
    /*font-size: 25px;*/
  }
</style>

