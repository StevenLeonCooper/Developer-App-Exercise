export class EventManager {

    constructor() {

        let MEM = window.MasterEventManager;

        if(MEM instanceof EventManager) return MEM;
        
        window.MasterEventManager = this;

        this.actions = {
            click: {},
            keydown: {},
            keyup: {},
            change: {}
        };

        this.promises = {
            click: {},
            change: {}
        };

        const self = this;

        function processEvent(type, eventObject) {

            let source = eventObject.target;

            let action = source.dataset.action ?? null;

            self.actions[type]?.[action]?.(eventObject);
        }

        document.addEventListener("click", (e) => {
            processEvent("click", e);
        });

        document.addEventListener("keyup", (e) => {
            processEvent("keyup", e);
        });

        document.addEventListener("keydown", (e) => {
            processEvent("keydown", e);
        });

        document.addEventListener("change", (e) => {
            processEvent("change", e);
        });

    }

    _wrapCallback(callback) {

        return function (event) {

            let eventData = new EventData(event);

            callback(eventData);
        };
    }


    on(type, name, callback) {


        this.actions[type][name] = this._wrapCallback(callback);
    }


}

export class EventData {
    constructor(event) {
        if (event instanceof EventData) return event;

        this.element = document.body;

        this.event = new Event("click");

        this.target = document.body;

        let actualTarget = document.querySelector(event.target?.dataset?.target);

        let eData = {
            element: event.target,
            event: event,
            targetElement: actualTarget
        };

        let dataSet = event.target?.dataset;

        Object.assign(this, eData);

        Object.assign(this, dataSet);
    }
}