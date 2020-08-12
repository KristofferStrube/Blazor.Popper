window.PopperWrapper = {
    createPopper: function (reference, popper, options, dotnetHelper) {
        options.onFirstUpdate = window.PopperWrapper.lookupStateAction(dotnetHelper, options.onFirstUpdate);
        const popperInstance = Popper.createPopper(reference, popper, options);
    },
    lookupStateAction: function (dotnetHelper, guid) {
        return (state) => {
            console.log(state);
            const stateCopy = {
                attributes: state.attributes,
                elements: state.elements,
                modifiersData: state.modifiersData,
                orderedModifiers: state.orderedModifiers,
                rects: state.rects,
                styles: state.styles
            }
            dotnetHelper.invokeMethodAsync('CallAction', guid, stateCopy)
        };
    }
}