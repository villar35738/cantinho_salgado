<template>
  <div>
    <Titulo texto="Estoque" />

    <div class="row">
      <table class="table table-bordered table-hover">
        <thead class="thead-dark">
          <tr>
            <th style="width: 66%">Nome do produto</th>
            <th class="textCenter" style="width: 20%">Quantidade</th>
            <th class="textCenter" style="width: 14%">Opções</th>
          </tr>
        </thead>

        <tbody v-if="produtos != ''">
          <tr v-for="(produto, index) in produtos" :key="index">
            <td>{{ produto.Nome }}</td>
            <td>{{ produto.Qtd }}</td>
            <td>
              <button class="btn btn-danger" @click="deletarProduto(produto)">
                DELETAR
              </button>
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          <tr>
            <td colspan="3" style="text-align: center">
              <h5>
                Nenhum produto encontrado
              </h5>
            </td>
          </tr>
        </tfoot>
      </table>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo,
  },
  props: {},
  data() {
    return {
      inputProduto: "",
      produtos: [],
    };
  },
  methods: {
    addProduto() {
      this.produtos.push(this.inputProduto);
      this.inputProduto = "";
    },
    deletarProduto(produto) {
      let indice = this.produtos.indexOf(produto);
      this.produtos.splice(indice, 1);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.row {
  padding-top: 10px;
}
</style>
