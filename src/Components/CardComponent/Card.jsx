import React from "react";

export default function Card({count,name,color,icon}) {
  return (
    <div class="col-lg-3 col-6">
      <div class={`small-box ${color}`}>
        <div class="inner">
  <h3>{count}</h3>

  <p>{name}</p>
        </div>
        <div class="icon">
          <i class={icon}></i>
        </div>
        <a href="#" class="small-box-footer">
          More info <i class="fas fa-arrow-circle-right"></i>
        </a>
      </div>
    </div>
  );
}
