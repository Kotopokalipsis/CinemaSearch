<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <h3 class="pb-3">Search Cinema</h3>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <b-form-group label="Options:" class="pb-2">
          <b-form-radio-group
                  v-model="selected"
                  :options="options"
                  name="radio-inline"
          ></b-form-radio-group>
        </b-form-group>
      </div>
    </div>
    <div class="d-flex">
      <div class="flex-grow-1">
        <b-form-input v-model="query" placeholder="Search films by options"></b-form-input>
      </div>
      <div class="ml-auto pl-3">
        <b-button variant="success" v-on:click="search" class="px-3">Search</b-button>
      </div>
    </div>
    <div class="mt-3 pt-2 border" v-for="film in films" v-bind:key="film.title">
      <div class="d-flex justify-content-center mb-1 mt-1 pb-0">
        <strong class="text-center">{{ film.title }}</strong>
      </div>
      <div class="d-flex justify-content-center mb-0 mt-1 pb-0">
        <small class="text-center">Genre: {{ film.genre }}</small>
      </div>
      <div class="d-flex justify-content-center mb-0 pb-0">
        <small class="text-center">Actors:</small>
      </div>
      <div class="d-flex justify-content-center mb-1 pb-0" v-for="actor in film.actor" v-bind:key="actor.name">
        <small class="text-center">{{ actor.name }}</small>
      </div>
      <div class="d-flex justify-content-center mb-2 mt-2 pb-0">
        <p class="text-center">{{ film.description }}</p>
      </div>
    </div>
  </div>
</template>

<script src="./search.js"></script>