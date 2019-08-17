export interface IEmotion {
    name: string;
    type: EmotionType;
}

export enum EmotionType {
    Happy,
    Sad,
    Disgusted,
    Angry,
    Fearful,
    Bad,
    Surprised
}