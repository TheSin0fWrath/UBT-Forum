import Threads from "../Shared/Components/Threads";
import Forum from "../Shared/Components/Forum";
import React from "react";

export default function Announcments() {
  return (
    <div class="Anncouncment">
      <Threads title="Announcments" desc="this desc" path="/announcments">
        <Forum
          icon="i"
          name="Tips For Visual Studio"
          desc="Started by bankercion"
          threads="22"
          posts="22"
          lastPost="This post"
        />
        <Forum
          icon="i"
          name="Best Virtual Machine Tools"
          desc="Started by bankercion"
          threads="22"
          posts="22"
          lastPost="This post"
        />
        <Forum
          icon="i"
          name="Simple Design Tools"
          desc="Started by bankercion."
          threads="22"
          posts="22"
          lastPost="This post"
        />
      </Threads>
      <div></div>
    </div>
  );
}
