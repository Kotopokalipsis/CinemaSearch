import axios from "axios";
import filmObject from "../../objects/filmObject.js";

var url;

export default {
    data() {
        return {
            query: '',
            selected: 'title',
            options: [
                { text: 'Title', value: 'title' },
                { text: 'Genre', value: 'genre' },
                { text: 'Actor', value: 'actor' }
            ],
            films: "",
        }
    },
    mounted() {
        axios
            .get("http://localhost:50598/api/search/all")
            .then(response => {
                // eslint-disable-next-line no-console
                console.log(response);
                this.films = filmObject.mapResponseToFilmObject(response);
            })
            .catch(err => {
                // eslint-disable-next-line no-console
                console.log(err);
            });
    },
    methods: {
        search: function () {
            switch (this.selected) {
                case 'title': url = "http://localhost:50598/api/search/title"; break;
                case 'genre': url = "http://localhost:50598/api/search/genre"; break;
                case 'actor': url = "http://localhost:50598/api/search/actor"; break;
            }
            axios
                .get(url, {
                    params: {
                        query: this.query
                    }
                })
                .then(response => {
                    this.films = filmObject.mapResponseToFilmObject(response);
                })
                .catch(err => {
                    // eslint-disable-next-line no-console
                    console.log(err);
                });
        },
    }
}