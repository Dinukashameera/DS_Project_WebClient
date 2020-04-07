import React from "react";

export default function Footer() {
  return (
    <div className='bg-dark d-flex justify-content-center' style = {style.body}>
      <div className="footer-dark ">
        <footer>
          <div className="container">
            <div className="row">
              <div className="col item social">
                <a href="#">
                  <i className="fab fa-google-plus-square fa-3x  mr-3 mb-3 mt-3" style={style.icon}></i>
                </a>
                <a href="#">
                  <i className="fab fa-twitter-square fa-3x  mr-3 mb-3 mt-3"></i>
                </a>
                <a href="#">
                  <i className="fa fa-facebook-square fa-3x mr-3 mb-3 mt-3"></i>
                </a>

              </div>
            </div>
            <p className="copyright text-light">Company Name © 2020</p>
          </div>
        </footer>
      </div>
    </div>
  );
}


const style = {
    body : {
       height:'150px',
       marginTop : '75px'
    },
    icon : {
        size :'35px'
    }
}