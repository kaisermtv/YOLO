<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vote.ascx.cs" Inherits="FrontEnd_Controls_Common_Vote" %>


<div class="YOLOVote">
    <h3>Bạn thấy website này có đẹp không?</h3>
    <ul>
        <li>
            <input class="deriku-radio-input" id="Yolo-vote-1" name="yolo-vote" value="1" type="radio">
            <label for="Yolo-vote-1" class="deriku-radio-label">
                <span></span>
                <div class="vote-percent-m">
                    <p>Rất đẹp</p>
                    <div class="vote-percent p50">
                        <div class="vote-percent-r" style="width: 50%;"></div>
                    </div>
                </div>
            </label>
        </li>
        <li>
            <input class="deriku-radio-input" id="Yolo-vote-2" name="yolo-vote" value="2" type="radio">
            <label for="Yolo-vote-2" class="deriku-radio-label">
                <span></span>
                <div class="vote-percent-m">
                    <p>Bình thường</p>
                    <div class="vote-percent p50">
                        <div class="vote-percent-r" style="width: 50%;"></div>
                    </div>
                </div>
            </label>
        </li>
        <li>
            <input class="deriku-radio-input" id="Yolo-vote-3" name="yolo-vote" value="2" type="radio">
            <label for="Yolo-vote-3" class="deriku-radio-label">
                <span></span>
                <div class="vote-percent-m">
                    <p>Hơi xấu</p>
                    <div class="vote-percent p50">
                        <div class="vote-percent-r" style="width: 50%;"></div>
                    </div>
                </div>
            </label>
        </li>
        <li>
            <input class="deriku-radio-input" id="Yolo-vote-4" name="yolo-vote" value="2" type="radio">
            <label for="Yolo-vote-4" class="deriku-radio-label">
                <span></span>
                <div class="vote-percent-m">
                    <p>Xấu tệ</p>
                    <div class="vote-percent p50">
                        <div class="vote-percent-r" style="width: 50%;"></div>
                    </div>
                </div>
            </label>
        </li>
    </ul>
    <a href="javascript:;" class="btn btn-success btn-vote">Bình chọn</a>
</div>

<script type="text/javascript">
    $('.btn-vote').click(function(e) {
        e.preventDefault();
        $(this).hide();
        $(this).parents('.YOLOVote:first').addClass('voted');
    });
</script>
