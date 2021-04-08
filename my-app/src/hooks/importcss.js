// import "../Components/ComponentCss/";
export default function importcss(path,style){
   
   path= path.toLowerCase();

    if (window?.location.pathname.toLowerCase() === `${path}`)
   require(`../Components/ComponentCss/${style}`)
}