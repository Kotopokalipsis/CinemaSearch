export default class filmObject {
    title = "";
    description = "";
    genre = "";
    dateOfCreation = "";
    actor = "";
    
    constructor(title, description, genre, dateOfCreation, actorResources)
    {
        this.title = title;
        this.description = description;
        this.genre = genre;
        this.dateOfCreation = dateOfCreation;
        this.actor = actorResources;
    }

    static mapResponseToFilmObject(response) {
        let filmArray = [];
        // eslint-disable-next-line no-console
        // console.log(response);
        
        response.data.forEach(function (currentValue) {
            // let currentValue = JSON.parse(currentValueJSON);
            // eslint-disable-next-line no-console
            // console.log(currentValue);
            let film = new filmObject(
                currentValue.title,
                currentValue.description,
                currentValue.genre,
                currentValue.dateOfCreation,
                currentValue.actorResources,
            );

            filmArray.push(film);
        })
        // // eslint-disable-next-line no-console
        // console.log(filmArray);
        return filmArray;
    }
}