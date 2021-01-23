export function createPopper(reference, popper, options) {
    options.onFirstUpdate = (state) => options.objRef.invokeMethodAsync('CallOnFirstUpdate', stripState(state));
    if (options.modifiers != null) {
        options.modifiers = options.modifiers.map(modifier => {
            var objRef = modifier.objRef;
            modifier.fn = (modifierArguments) => {
                modifierArguments.state = stripState(modifierArguments.state);
                delete modifierArguments.instance;
                delete modifierArguments.options;
                objRef.invokeMethodAsync('CallFn', modifierArguments);
            }
            delete modifier.objRef;
            return modifier;
        });
    }

    return Popper.createPopper(reference, popper, options);
}

export function getStateOfInstance(instance) {
    return stripState(instance.state)
}

export function updateOnInstance(instance) {
    return instance.update().then(state => stripState(state));
}

export function setOptionsOnInstance(instance, options) {
    options.onFirstUpdate = (state) => {
        options.objRef.invokeMethodAsync('CallOnFirstUpdate', stripState(state))
    };
    return instance.setOptions(options).then(state => stripState(state));
}

export function getStateOfModifierArguments(modifierArguments) {
    return stripState(modifierArguments.state)
}

export function stripState(state) {
    return {
        placement: state.placement,
        attributes: state.attributes,
        elements: state.elements,
        modifiersData: state.modifiersData,
        orderedModifiers: state.orderedModifiers,
        rects: state.rects,
        styles: state.styles
    }
}