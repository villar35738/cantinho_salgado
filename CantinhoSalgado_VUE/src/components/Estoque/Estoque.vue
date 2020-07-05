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
          <tr
            v-for="(produto, index) in produtos"
            :key="index"
            :class="{ editing: produto == editedProduct }"
            v-cloak
          >
            <td>
              {{ produto.produtoNome }}
            </td>
            <td>
              <div class="view textCenter">
                {{ produto.qtdEstoque }}
              </div>
              <div class="edit">
                <input
                  type="text"
                  style="text-align: center;"
                  v-model="produto.qtdEstoque"
                  ref="inputQtdEstoque"
                />
              </div>
            </td>
            <td class="textCenter">
              <div class="view">
                <button class="btn btn-primary" @click="editarProduto(produto)">
                  EDITAR
                </button>
              </div>
              <div class="edit">
                <button class="btn btn-success" @click="salvarProduto(produto)">
                  SALVAR
                </button>
              </div>
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
      editar: false,
      editMode: false,
      editedProduct: "",
    };
  },
  methods: {
    carregarEstoque() {
      this.$http
        .get(`http://localhost:5000/estoque/${false}`)
        .then((res) => res.json())
        .then((produtos) => {
          this.produtos = produtos;
        });
    },
    editarProduto(produto) {
      this.editedProduct = produto;
      let indice = this.produtos.indexOf(produto);
      setTimeout(() => {
        this.$refs.inputQtdEstoque[indice].focus();
        this.$refs.inputQtdEstoque[indice].select();
      }, 5);
    },
    salvarProduto(produto) {
      this.editedProduct = !produto;
      var EstoqueID = produto.estoqueID;

      this.$http.put(
        `http://localhost:5000/estoque/${EstoqueID}/${produto.qtdEstoque}`
      );
    },
  },
  created() {
    this.carregarEstoque();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.row {
  padding-top: 10px;
}

[v-cloak] {
  display: none;
}
.edit {
  display: none;
}
.editing .edit {
  display: block;
}
.editing .view {
  display: none;
}
</style>
