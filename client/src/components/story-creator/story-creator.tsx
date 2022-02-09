import * as React from 'react';
import Input from '../input/input';
import Button from '../button/button';
import { createStory, finishStory } from '../../api/api';
import { ICard, IRoom, IRootState, UserId } from '../../store/types';
import { updateRoom } from '../../store/room/room-action-creators';
import { Dispatch } from 'redux';
import { connect } from 'react-redux';
import { roomSelector } from '../../store/room/room-selector';
import './story-creator.css';

interface IProps {
  updateRoom: (room: IRoom) => void;
  room: IRoom | null;
}

const StoryCreator: React.FC<IProps> = (props) => {
  const storyNameRef: React.RefObject<HTMLInputElement> = React.createRef();

  const handleCreateStory = () => {
    const { current: storyName } = storyNameRef;
    if (storyName && props.room) {
      const response = createStory(props.room, storyName.value);
      if (response != null) {
        props.updateRoom(response);
      }
    }
  }

  const getCountVotes = (votes: Record<UserId, ICard>): number => {
    let count = 0;
    for (const key in votes) {
      count++;
    }
    return count;
  }

  const handleFinish = () => {
    if (props.room) {
      const currentStory = props.room.stories[props.room.stories.length - 1];
      if (getCountVotes(currentStory.votes) === props.room.users.length) {
        const response = finishStory(props.room);
        if (response != null) {
          props.updateRoom(response);
        }
      }
    }
  }

  const getStatusLastStory = (room: IRoom) => {
    const { stories } = room;
    if (stories.length > 0) {
      return stories[stories.length - 1].isOver;
    }
    return true;
  }

  return (
    <div className="story-creator">
      {props.room && getStatusLastStory(props.room) == false && <Button onClick={handleFinish} className="button button-finish" title='Finish Voting' />}

      {props.room && getStatusLastStory(props.room) == true &&
        <div>
          <Input ref={storyNameRef} inputClassName='input story-creator__input' name='discussionName' required={true} />
          <Button className='story-creator__button' title='Go' onClick={handleCreateStory} />
        </div>
      }
    </div>
  )
}

const mapStateToProps = (state: IRootState) => {
  return {
    room: roomSelector(state),
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateRoom: (room: IRoom) => {
      dispatch(updateRoom(room));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(StoryCreator);