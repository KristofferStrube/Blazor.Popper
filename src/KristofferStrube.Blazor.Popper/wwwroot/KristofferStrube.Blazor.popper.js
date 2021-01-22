export function createPopper(reference, popper, options, objRef) {
    options.onFirstUpdate = (state) => {
        objRef.invokeMethodAsync('CallOnFirstUpdate', stripState(state))
    };

    return Popper.createPopper(reference, popper, options);
}

export function getStateOfInstance(instance) {
    return stripState(instance.state)
}

export function updateOnInstance(instance) {
    return instance.update().then(state => stripState(state));
}

export function setOptionsOnInstance(instance, options, objRef) {
    options.onFirstUpdate = (state) => {
        objRef.invokeMethodAsync('CallOnFirstUpdate', stripState(state))
    };
    return instance.setOptions(options).then(state => stripState(state));
}

function stripState(state) {
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