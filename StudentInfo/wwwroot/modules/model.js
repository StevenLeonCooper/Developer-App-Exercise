import {GET, POST, PUT, DELETE} from './request.js';

export class Model{

    constructor(settings) {
        if (settings instanceof Model) return settings;

        this.id = settings.id ?? null;
        this.created = settings.created ?? null;
        this.data = settings.data ?? null;
        this.apiUrl = settings.apiUrl ?? null;
        this.relatives = settings.relatives ?? null;
    }

    async import(){

        let request = new GET("JSON");

        let result = await request.from(this.apiUrl).send();

        result = result.length == 1 ? result[0] : result;

        this.data = result;

        window.test = result;

        return this;
    }

 
    async get(){
        let request = new GET("JSON");
        
        return request;

    }

    export(){
        return JSON.parse(JSON.stringify(this.data));
    }

}