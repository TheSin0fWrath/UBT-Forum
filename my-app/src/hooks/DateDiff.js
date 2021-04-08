export default function timeDiffCalc( dateFuture) {
    var dateNow =new Date();
    dateFuture=new Date(dateFuture);
    
    let diffInMilliSeconds = Math.abs(dateFuture- dateNow) / 1000;
 

    // calculate hours
    const hours = Math.floor(diffInMilliSeconds / 3600) % 24;
    diffInMilliSeconds -= hours * 3600;
   

    // calculate minutes
    const minutes = Math.floor(diffInMilliSeconds / 60) % 60;
    diffInMilliSeconds -= minutes * 60;


    let difference = '';
   
if (hours>0){
    difference +=  `${hours}h ago `;
    return difference;
}
else if (minutes>0){
    difference +=  `${minutes}m ago`; 
    return difference;
}

    return difference="now";
  }
