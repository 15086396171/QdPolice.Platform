<template>
  <div>
    <group>
      <cell v-for="(item,index) in documents" :key="item.id" :title="item.title" :link="'/docDetails/'+item.id">
        <div class="badge-value" v-if="!item.isRead">
          <badge></badge>
        </div>
      </cell>
    </group>
  </div>
</template>
<script>
  import { Group, Cell, Badge } from 'vux'
  import documentService from '../../services/document/documentService'
  export default {
    components: {
      Group,
      Cell,
      Badge
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
