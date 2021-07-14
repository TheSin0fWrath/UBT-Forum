import React, { useContext, useEffect, useMemo, useState } from 'react';
import EmptyPage from "../Components/EmptyPage";

export default function RepPage  ({path,children}){

return(
<div className="Reputation">
        <EmptyPage path="/reputation">
            {children}
        </EmptyPage>
</div>
)
}
