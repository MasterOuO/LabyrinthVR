<h1 align="center">轉動迷宮(VR)</h1>

## 介紹
《轉動迷宮(VR)》是一款運用虛擬實境技術的迷宮解謎遊戲。遊戲中，玩家需要使用 Google Cardboard 設備原地踏步，控制角色在虛擬迷宮中探索。玩家的目標是通過旋轉道路方塊，連接不同的道路，找到迷宮的出口。  

## 動機
創建這款遊戲的動機在於結合虛擬現實技術和益智解謎遊戲，為玩家帶來沉浸式的遊戲體驗。同時，使用 Google Cardboard 相對便宜且易於獲得的VR設備，讓更多人能夠體驗虛擬現實遊戲的樂趣。  

## 目的
《轉動迷宮》提供一個沉浸式的遊戲體驗，讓玩家在解謎過程中感受到虛擬現實帶來的刺激和樂趣。遊戲中，玩家需要運用觀察力和策略思維，找到通往迷宮出口的正確道路。  

## 技術和工具
程式語言 : C#、Java  
開發環境 : Unity、AndroidStudio  
硬體設備 : Android手機、Google Cardboard  

## 用戶端介紹
### 硬體設備
將 APK 安裝到 Android 手機中，並將手將放入 Google Cardboard 完成簡易VR裝置。  
<img src="https://github.com/MasterOuO/LabyrinthVR/blob/main/show/4.jpg" width="200px">
<img src="https://github.com/MasterOuO/LabyrinthVR/blob/main/show/5.jpg" width="200px">
### 移動操作
玩家戴上 Google Cardboard 透過通過轉動頭部以及原地踏步來觀察迷宮環境。  
<img src="https://github.com/MasterOuO/LabyrinthVR/blob/main/show/3.jpg" width="400px">
### 轉動方塊
玩家將准心對準方塊並使用 Google Cardboard 按鈕點擊來轉動道路方塊的旋轉。  
<img src="https://github.com/MasterOuO/LabyrinthVR/blob/main/show/2.jpg" width="400px">
### 標記
玩家長按 Google Cardboard 按鈕點擊在當前位置地板上進行標記。  
<img src="https://github.com/MasterOuO/LabyrinthVR/blob/main/show/1.jpg" width="400px">

##迷宮創建
以防止死路為目的進行創建，從起點開始，每一圈的轉動方塊是否都在可進入範圍，確保每一圈的方塊玩家都能進入。  
在迷宮創建時，從起點為頭，由左至右一圈進行創建，同時確保目前所創建的這圈中為可進入範圍，直到創建完畢。  
<img src="https://github.com/MasterOuO/LabyrinthVR/blob/main/show/4.gif" width="400px">

##影片連結
<a href="https://www.youtube.com/watch?v=CN_U5atPzEM">youtube影片連結</a>
