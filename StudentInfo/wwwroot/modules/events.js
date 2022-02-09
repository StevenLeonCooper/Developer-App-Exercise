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

    on(type, name, callback) {
        this.actions[type][name] = callback;
    }


}