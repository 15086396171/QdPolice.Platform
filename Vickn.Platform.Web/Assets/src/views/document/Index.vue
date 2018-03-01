<template>
  <div>
    <group>
      <cell v-for="(item,index) in documents" :key="item.id" :title="item.title" :link="'/docDetails/'+item.id"></cell>
    </group>
  </div>
</template>
<script>
  import { Group, Cell } from 'vux'
  import documentService from '../../services/document/documentService'
  export default {
    components: {
      Group,
      Cell,
    },
    data() {
      return {
        documents: []
      }
    },
    created() {
      this.fecthData()
    },
    methods: {
      async fecthData() {
        let ret = await documentService.getLastAsync({});
        this.documents = ret.items
      }
    }
  }
</script>
