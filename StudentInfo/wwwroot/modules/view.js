import Mustache from './mustache.js';
import { GET } from './request.js';

export class View {
    constructor(name, path, ext) {

        if (name instanceof View) return name;


        path = path ?? "_view/";
        ext = ext ?? "html";
        this.url = `${path}${name}.${ext}`;
        this.selector = `#view_${name}`;
        this.data = null;
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
        return this;
    }

}

export class Partial extends View {
    constructor(name, settings) {
        super(name, "_view/_partial/", "html");
        this.selector = settings.selector ?? `#partial_${name}`;
    }
}

