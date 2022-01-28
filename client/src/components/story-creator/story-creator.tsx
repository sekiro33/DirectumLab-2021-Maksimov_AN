import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import './story-creator.css';

const StoryCreator: React.FC = () => {
  return (
    <div className="story-creator">
      <Input inputClassName='input story-creator__input' name='discussionName' required={true} />
      <Button className='story-creator__button' title='Go' />
    </div>
  )
}

export default StoryCreator;