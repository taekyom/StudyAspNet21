namespace DotNetNote.Models
{
    public enum BoardWriteFormType //enum : 열거
    {
        Write,  //글쓰기 모드
        Modify, //글수정 모드
        Reply   //댓글 모드
    }
    public enum ContentEncodingType
    {
        Text,   //일반 텍스트 모드
        Html,   //HTML 입력 모드
        Mixed   //HTML입력 + 엔터키모드(HTML에서는 엔터-><br/>)
    }
}