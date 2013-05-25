Hangman – Бесилкa
=================

<b>Семинарска задача по предметот Визуелно програмирање</b>


Опис на играта „Hangman - Бесилка“
----------------------------------------

  Семинарската задача ја опфаќа добро познатата игра „Бесилка“. 
Во класичната игра целта е да се погодат сите букви од зборот / зборовите за да се победи,
или во спротива, се „беси“ човечето. Тоа му дава на играчот шанса од 5 погрешени 
букви за да го открие целиот збор без да биде обесен.

  Во овој случај, ние ја имплементираме играта скоро исто како класичната. 
Разликата е во тоа што на играчот му даваме шанса да избере кој карактер 
може да го „беси“ доколку погреши некоја буква. Изборот се сведува на 8 професори 
од Факултетот за информатички науки и компјутерско инженерство.

Објаснување на имлементацијата на играта
----------------------------------------

Играта е изработена во програмскиот јазик C#. Се состои од четири прозори (форми). 
Главната форма (првата форма) е главното мени каде се гледаат четири можни опции:

  * Start new game – копче за почеток на игра
  * Highscores – копче за информации за осцоени поени
  * About – копче за информации за креторите на играта
  * Exit – копче за излез од играта

<img src="http://img443.imageshack.us/img443/9383/slika1x.jpg"/>

Со кликннување на опцијата <b><i>START NEW GAME</i></b> се отвара втората форма каде се прави 
изборот на каратктерот кој ќе се „беси“, односно ликот од еден од осумте професори од ФИНКИ. 
Исто така овозможени се и две копчиња <b><i>EXIT</i></b> и <b><i>BACK</i></b> со кои му се дава избор на играчот 
да се врати назад во главното мени, или пак излез од самата игра.

<img src="http://img515.imageshack.us/img515/3926/slika2b.jpg"/>

Со кликнување на ликот на саканиот професор играта започнува во нов прозорец. 
Тука може да се види класичниот дизајн на бесилката, каде ќе се „беси“ карактерот со секоја 
погрешена буква.

<img src="http://imageshack.us/a/img198/6727/slika3.JPG"/>

Во долниот предел на прозорецот се гледаат празните цртички кои се заменуваат 
со букви, доколку играчот погоди буква од зборот / зборовите. Се разбира доколку играчот 
погреши некоја буква, прво се исцртува главата на избраниот професор, а потоа и останатите 
делови од телото. За да биде малце позабавна и поинтересна играта, телото на професорите 
е всушност човечки скелет. 

Доколку играчот успее да ги погоди сите букви од зборот се отвара нов прозорец каде се 
прикажани освоените понеи, и каде има празно поле за внесување на името на играчот, 
како би се зачувал резултатот во делот <b><i>HIGHSCORES</i></b>.

<img src="http://imageshack.us/a/img153/7595/slika4k.jpg"/>

Со внесување на името на играчот, и кликнување на копчето <b><i>OK</i></b>, играта аутоматски го враќа 
играчот во главното мени. И во овој прозорец е овозможено копчето <b><i>EXIT</i></b>.

Да се вратиме назад на првиот прозорец. Доколку играчот сака да провери кои резултати се 
зачувани во играта, може да кликне на копчето <b><i>HIGHSCORES</i></b>. Со кликнување на ова копче, 
се отвара листата која ги соджри сите зачувани резултати, сортирани по опаѓачки редослед.

<img src="http://img89.imageshack.us/img89/3787/slika5aa.jpg"/>

Исто така доколку играчот сака, овозможено му е да ја избрише целата листа со поени, со 
помош на копчето <b><i>CLEAR</i></b>. Во случај листата веќе да е празна, тоа копче е оневозможено.

Последната опција од главното мени е опцијата <b><i>ABOUT.</i></b> Тука може да се видат информациите за 
креаторите на играта.

<img src="http://img845.imageshack.us/img845/1005/slika6m.jpg"/>


Подетален опис за изворниот код
-------------------------------

Најголемиот проблем во играта беше да се овозможи исцртувањето на цртичките, и нивната замена со букви 
бидејќи секој збор / зборови има различен број на букви. За разлика од сликичките за деловите на телото 
на карактерот и некои од копчињата, кои во зависност од моменталната ситуација се кријат или покажуваат 
со функцијата <i>.Hide()</i> или <i>.Show()</i>, кај буквите тоа не беше возможно.
  
Проблемот го решивме така што направивме мала база на податоци, во која се чуваат професорите во одделна 
табела, и за секој се чуваат одделени зоборови. Исто така во базата се чуваат и податоците за поените на 
играчите. Речиси целата функционалност на играта е овозможена во формата <b><i>GAME</i></b>. Конкретно за проблемот 
со буквите, направивме две листи од „PictureBox“ во кои се содржат цртичките и буквите на моменталниот збор
кој е избран од базата случајно. 

Цртичките:

    // Picture Start
    PictureBox tmpPicure = new PictureBox();
    tmpPicure.Size = new Size(40, 40);
    tmpPicure.Location = new Point(380 + i * 35, 400);
    tmpPicure.Image = Image.FromFile(@"Letters\_.png");
    tmpPicure.BackColor = System.Drawing.Color.Transparent;
    tmpPicure.Show();
    picturesStart.Add(tmpPicure);
    this.Controls.Add(tmpPicure);
 
Буквите: 

    // Picture
    PictureBox realPicture = new PictureBox();
    realPicture.Size = new Size(40, 40);
    realPicture.Location = new Point(380 + i * 35, 400) 
    realPicture.BackColor = System.Drawing.Color.Transparent;
    realPicture.Hide();
    string location = @"Letters\" + choosenWord[i] + ".png";
    realPicture.Image = Image.FromFile(location);
    pictures.Add(realPicture);
    this.Controls.Add(realPicture);

Во функцијата <i>Game_KeyPress</i> каде се детектира притискањето на копче, со помош на <i>FOR</i> циклус 
се врши проверката на тоа дали притиснатото копче е содржано во зборот, и доколку е се врши замената 
на цртичката со буква.

    for (int i = 0; i < choosenWord.Length; i++)
                {
                    if (choosenWord[i] == tmpKey)
                    {
                        found = true;
                        pictures[i].Show();
                        picturesStart[i].Hide();
                    }
                }

Во истата функција се врши и пресметката на поени освоени на играчот со секоја точно погодена буква.



Изработиле
--------------

Јован Самарџиски бр. на индекс 111183<br>
Димитар Стојчев бр. на индекс 111214
