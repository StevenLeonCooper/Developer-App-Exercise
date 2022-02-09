import { View, Partial } from './view.js';
import { Model } from './model.js';
import { EventManager } from './events.js';

/**
 * @param {string} modelName Name of the Model
 * @param {string} viewName Name of the View
 */
export class Controller {
    constructor(view, model) {

        this.view = new View(view);

        this.model = new Model(model);

        this.partials = {};

        this.EventManager = new EventManager();

        if (!model instanceof Model) {
            throw ("Incorrect Data Type");
        }
    }

    async setup() {

        await this.view.import();

        await this.model.import();

        return this;
    }

    async getPartial(name) {

        let partial = new Partial(name);

        this.partials[name] = partial;

        await partial.import();

        return partial;
    }

    onClick(name, callback) {
        this.EventManager.on("click", name, callback);
    }

    onKeyUp(name, callback) {
        this.EventManager.on("keyup", name, callback);
    }

    onKeyDown(name, callback) {
        this.EventManager.on("keydown", name, callback);
    }

    onChange(name, callback) {
        this.EventManager.on("change", name, callback);
    }

} 