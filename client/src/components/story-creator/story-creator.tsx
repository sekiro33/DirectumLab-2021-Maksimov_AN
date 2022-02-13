import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import './story-creator.css';

<<<<<<< Updated upstream
const StoryCreator: React.FC = () => {
  return (
    <div className="story-creator">
      <Input inputClassName='input story-creator__input' name='discussionName' required={true} />
      <Button className='story-creator__button' title='Go' />
=======
interface IProps {
  isVoted: boolean;
  createDiscussion: (name: string) => void;
  finishDiscussion: () => void;
}

const StoryCreator: React.FC<IProps> = (props) => {
  const storyNameRef: React.RefObject<HTMLInputElement> = React.createRef();

  const handleCreateDiscussion = () => {
    const { current: storyName } = storyNameRef;
    if (storyName) {
      props.createDiscussion(storyName.value);
    }
  }

  const handleFinishDiscussion = () => {
    props.finishDiscussion();
  }

  return (
    <div className="story-creator">
      {!props.isVoted ?
        <Button onClick={handleFinishDiscussion} className="button button-finish" title='Finish Voting' />
        :
        <div>
          <Input ref={storyNameRef} inputClassName='input story-creator__input' name='discussionName' required={true} />
          <Button onClick={handleCreateDiscussion} className='story-creator__button' title='Go' />
        </div>
      }
>>>>>>> Stashed changes
    </div>
  )
}

export default StoryCreator;