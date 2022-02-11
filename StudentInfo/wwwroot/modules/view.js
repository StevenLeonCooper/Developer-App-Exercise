import Mustache from './mustache.js';
import { GET } from './request.js';

export class View {
    constructor(name, deps) {

        if (name instanceof View) return name;
            this.data = null,
            this.css = false,
            this.name = name,
            this.selector = `#view_${name}`,
            this.path = null,
            this.ext = null;


        // Inject dependencies if present
        if (deps instanceof Object) Object.assign(this, deps);

        this.path = this.path ?? "_view/";
        this.ext = this.ext ?? "html";
        this.url = `${this.path}${this.name}.${this.ext}`;

    }

    async import(url) {
        url = url ?? this.url;

        let req = new GET("HTML").from(url);

        let html = await req.send();

        this.html = html;

        return this;
    }

    render(data) {
        let template = this.html;
        data = data ?? this.data ?? {};
        let output = Mustache.render(template, data);
        document.querySelector(this.selector).outerHTML = output;

        if (this.css === false) return this;

        let stylesheet = `<link rel="stylesheet" href="css/${this.name}.css" />`;

        document.head.insertAdjacentHTML("beforeend", stylesheet);

        return this;
    }

}

export class Partial extends View {
    constructor(name, settings) {
        let partialSettings = {
            path: "_view/_partial/",
            ext: "html"
        };
        super(name, partialSettings);

        this.selector = settings.selector ?? `#partial_${name}`;
    }
}

