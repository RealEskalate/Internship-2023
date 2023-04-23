
// type Blog  = {
//     title : string,


// }

// interface props {
//     title : Blog.title,

// };

const singleBlog = ({}) => {
  return (
    <div className="bg-white">
        <h2 className="text-center blog-title pt-4">
            The essential guide to Competitive Programming
        </h2>
        <p className="text-center uppercase blog-sub-title">
            Programming, tech | 6 min Read
        </p>
        <div className="flex h-auto w-5/6  justify-center items-center mx-auto p-8">
            <img src="/blogImg.png" className="mx-auto" alt="blog image"/>
        </div>

        <div className="mx-auto p-4">
            <img src="/small-blog-img.png" className="mx-auto p-4"/>
            <div className="">
                <p className="mx-auto text-center uppercase font-normal blog-sub-title">chaltu kebede | software engineer</p>
                <a className="text-center " href="#"><p className="text-center uppercase font-semibol text-blue-600 link-color">@chaltu_kebede</p></a>
            </div>
        </div>
        <div className=" mx-auto pt-8 text-left w-4/6">
            <b className="bold-text">We know that data structure and algorithm can seem hard at first glance. And you
            may not be familiar with advanced algorithms, but there are simple steps you can
            follow to see outstanding results in a short period of time.</b>
            <br></br>
            <br></br>
            <small className="mt-8 small-text">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
             ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco 
             laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
            in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat 
            cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </small>
            <br></br>
            <br></br>
            <small className="pt-8 small-text">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
             ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco 
             laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
            in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat 
            cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </small>
            <br></br>
            <br></br>
            <small className="pt-8 small-text">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
             ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco 
             laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
            in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat 
            cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </small>
            <br></br>
            <br></br>
            <small className="pt-8 small-text">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
             ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco 
             laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit 
            in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat 
            cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </small>

        </div>
    </div>
 
  )
}

export default singleBlog