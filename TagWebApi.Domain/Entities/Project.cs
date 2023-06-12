using System.Collections.Generic;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public AITaskType AITaskType { get; set; }

    // Navigation properties
    public virtual ICollection<ProjectAssignment> Assignments { get; set; }
    public virtual ICollection<MainTask> Tasks { get; set; }
}


public enum AITaskType
{
    //Image
    Image_Classification,
    Object_Detection,
    Image_Segmentation,

    //Video
    Video_Annotation,

    //Text
    Text_Classification,//Classifying a piece of text into one of several predefined categories.
    NER, //Named Entity Recognition (NER): Identifying and classifying named entities in a piece of text.

    //Audio
    Audio_Classification,//Audio Classification: Classifying an audio clip into one of several predefined categories.
    Speech_To_Text, //Transcribing spoken words from an audio clip into text.
}
