export default function debounce(func: Function, ms: number) {
    console.log("debounce func")
    let timeout: ReturnType<typeof setTimeout>;
    return (...args: any) => {
        clearTimeout(timeout);
        timeout = setTimeout(() => func(...args), ms);
    };
}