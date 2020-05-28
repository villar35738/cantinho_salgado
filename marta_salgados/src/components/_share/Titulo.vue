<template>
  <div>
    <h1>{{ texto }}</h1>
    <hr />
  </div>
</template>

<script>
export default {
  props: {
    texto: String,
  },
};
</script>

<style scoped></style>
