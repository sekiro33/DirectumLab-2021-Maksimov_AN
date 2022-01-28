import * as React from 'react';
import './story-placeholder.css';

const StoryPlaceholder: React.FC = () => {
  return (
    <div className="story-placeholder">
      <p className="story-placeholder__text">Create new story</p>
    </div>
  );
};

export default StoryPlaceholder;