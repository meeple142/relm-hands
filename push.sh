#!/data/data/com.termux/files/usr/bin/bash
cd /data/data/com.termux/files/home/storage/shared/Code/RelmHands
echo Message for commit?
read -r message
git add .
git commit -m "$message"
git push
read waitingOnAPrayer