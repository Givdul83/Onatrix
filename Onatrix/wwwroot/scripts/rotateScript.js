export function rotateOnScroll() {
    const rotateElements = document.querySelectorAll('.rotate');

    function isElementInViewport(el) {
        const rect = el.getBoundingClientRect();
        return (
            rect.top < (window.innerHeight || document.documentElement.clientHeight) &&
            rect.bottom > 0
        );
    }

    function onScroll() {
        rotateElements.forEach(el => {
            if (isElementInViewport(el)) {
                el.classList.add('rotated');
            } else {
                el.classList.remove('rotated');
            }
        });
    }

    window.addEventListener('scroll', onScroll);
    onScroll();
}