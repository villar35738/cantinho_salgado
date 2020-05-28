<template>
  <div>
    <Titulo texto="Cadastro de produtos"></Titulo>

    <div class="row">
      <div class="input-group">
        <float-label style="width: 65%;">
          <input
            ref="inputProduto"
            type="text"
            class="form-control"
            placeholder="Nome do produto"
            v-model="inputProduto"
          />
        </float-label>
        <float-label style="width: 20%;">
          <currency-input
            v-model="inputProdutoPreco"
            currency="BRL"
            class="form-control"
            placeholder="Preço"
            @keyup.enter="addProduto()"
          />
          <!-- <input
            type="text"
            class="form-control"
            placeholder="Preço"
            v-model="inputProdutoPreco"
            @keyup.enter="addProduto()"
          /> -->
        </float-label>
        <button
          class="btn btn-primary"
          style="width: 14%; margin-left: 1%"
          @click="addProduto()"
        >
          <i class="fas fa-plus"></i>
        </button>
      </div>
    </div>
    <div class="row">
      <table class="table table-bordered table-hover">
        <thead class="thead-dark">
          <tr>
            <th style="width: 66%">Nome do produto</th>
            <th style="width: 26%">Preço</th>
            <th class="textCenter" style="width: 14%">Opções</th>
          </tr>
        </thead>

        <tbody v-if="produtos != ''">
          <tr v-for="(produto, index) in produtos" :key="index">
            <td>{{ produto.nome }}</td>
            <td>{{ produto.preco }}</td>
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
  data() {
    return {
      inputProduto: "",
      inputProdutoPreco: 0,
      produtos: [],
    };
  },
  methods: {
    addProduto() {
      let produto = {
        nome: this.inputProduto,
        preco: this.inputProdutoPreco,
      };
      this.produtos.push(produto);
      this.inputProduto = "";
      this.inputProdutoPreco = 0;

      this.$refs.inputProduto.focus();
    },
    deletarProduto(produto) {
      let indice = this.produtos.indexOf(produto);
      this.produtos.splice(indice, 1);
    },
  },
};
</script>

<style scoped>
.row {
  padding-top: 10px;
}
</style>
