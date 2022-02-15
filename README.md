# EnglishDictionary
영어사전을 구현한 알고리즘
## 1: 입력
입력을 통해 영어사전에 들어갈 단어를 입력합니다.
그 단어의 스펠링과 뜻을 입력받고, 스펠링을 기준으로 그 단어의 길이 값도 구해서 저장합니다.

단어의 길이 값을 key값삼아 이진탐색트리에 저장합니다.
이진탐색트리의 근노드는 맨 처음에 입력된 값이고, 부모노드보다 key값이 작은 노드는 왼쪽에, key값이 큰 노드는 오른쪽에 배치됩니다.
## 2: 삭제
모든 단어들은 각자의 번호를 가지고 있습니다. 삭제하고싶은 단어의 번호값을 입력하면 해당 번호값의 단어를 삭제합니다.
삭제 후 변경된 번호를 다시 순서에 맞게 맞춰줍니다.

ex)
1. apple 사과
2. orange 오렌지
3. school 학교

에서 2를 제거하면

1. apple 사과
2. school 학교

로 바뀜.

삭제할 단어가 없으면 삭제할 단어가 없다는 메시지를 띄우고 삭제를 실행하지 않습니다.
## 3: 탐색
찾으려는 영어 단어를 입력합니다.
찾으려는 단어의 길이를 이용해서 이진탐색트리에서 탐색을 진행합니다.
길이가 같은 단어중에서 같은 단어가 있는지 찾습니다.

원하는 단어를 찾으면 그 단어를 출력하고, 그렇지 않으면 탐색 과정에서 찾았던 비슷한 단어들을 출력합니다.
여기서 비슷한 단어는 "찾으려는 단어의 철자와 곂치는 철자를 찾으려는 단어의 길이 수 이상 가지고 있는 단어들"을 뜻합니다.

탐색할 단어가 없으면 탄색할 단어가 없다는 메세지를 띄우고 탐색을 실행하지 않습니다.
## 4: 출력
영어사전 내의 모든 단어들의 번호와 스펠링, 뜻을 출력합니다.
## 5: 정렬
영어사전 내의 모든 단어들을 정렬합니다.

정렬은 영어 스펠링은 기준으로 오름차순, 내림차순 정렬과 한국어 뜻 기준으로 오름차순, 내림차순 정렬을 진행 할 수 있으며, 이는 C#의 Linq를 통해서 진행됩니다.
## 6: 종료
프로그램을 종료합니다.
