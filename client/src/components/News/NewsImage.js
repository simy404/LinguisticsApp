import React from 'react';

function NewsImage({ src, alt }) {
  return (
    <img
      className="w-full h-64 object-cover rounded-t-lg"
      src={src}
      alt={alt}
    />
  );
}

export default NewsImage;
