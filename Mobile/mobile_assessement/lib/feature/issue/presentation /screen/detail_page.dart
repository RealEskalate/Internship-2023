import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../bloc/issue_bloc.dart';
import '../bloc/issue_event.dart';
import '../bloc/issue_state.dart';
import '../../domain/repositort/issue_repository.dart';
class detailpage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final fem = 10.0; // assign a value to fem
    final ffem = 1.2; // assign a value to ffem
    final issueBloc = BlocProvider.of<IssueBloc>(context);

    return Scaffold(
      body: 
Container(

  child: Container(
    
  // detailmEs (0:2)
  width:  double.infinity,
  decoration:  BoxDecoration (
    color:  Color(0xfff5f4ff),
  ),
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // autogroup6ve3RKR (2Z9k7mb8di7Nx6jzXQ6Ve3)
  padding:  EdgeInsets.fromLTRB(24*fem, 55*fem, 42.5*fem, 17*fem),
  width:  double.infinity,
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // autogroup9oqxXtF (2Z9hzuxB4rfUo9TFqq9oQX)
  margin:  EdgeInsets.fromLTRB(3*fem, 0*fem, 0*fem, 16*fem),
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // icomenuG59 (0:480)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 87*fem, 0*fem),
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'), 
  width: 24*fem,
  height: 24*fem,
)
),
Container(
  // autogroupuuwfmXh (2Z9iCjwoN22R3mgaw6UUWf)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 72*fem, 0*fem),
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Text(
  // newmexicoK3R (0:479)
  'New Mexico',
  textAlign:  TextAlign.center,
  style: TextStyle (
    fontSize:  18*ffem,
    fontWeight:  FontWeight.w700,
    height:  1.1725*ffem/fem,
    color:  Color(0xff211772),
  ),
),
Container(
  // sunnovember162yR (0:478)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  'Sun, November 16',
  textAlign:  TextAlign.center,
  style: TextStyle (
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xff575757),
  ),
),
),
  ],
),
),
Container(
  // group7V5 (108:26)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 0*fem, 0*fem),
  width:  22.5*fem,
  height:  20.06*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // mostlysunnyRVm (0:441)
  margin:  EdgeInsets.fromLTRB(18.5*fem, 0*fem, 0*fem, 7*fem),
  padding:  EdgeInsets.fromLTRB(23.75*fem, 23.75*fem, 23.75*fem, 23.75*fem),
  decoration:  BoxDecoration (
    color:  Color(0x00f1f1f2),
    boxShadow:  [
      BoxShadow(
        color:  Color(0x33211772),
        offset:  Offset(5*fem, 7*fem),
        blurRadius:  14*fem,
      ),
    ],
  ),
  child:  
Center(
  // group7tP (0:443)
  child:  
SizedBox(
  width:  237.5*fem,
  height:  237.5*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
),
),
Container(
  // mostlysunnyFDu (0:472)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 0*fem, 4*fem),
  child:  
Text(
  'Mostly Sunny',
  style:  TextStyle (
    fontSize:  24*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.1725*ffem/fem,
    color:  Color(0xff9f93ff),
  ),
),
),
Container(
  // group2Abm (0:473)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 196.5*fem, 0*fem),
  width:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // 5yd (0:474)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 3*fem, 0*fem),
  child:  
Text(
  '30',
  style:  TextStyle (
    fontSize:  72*ffem,
    fontWeight:  FontWeight.w700,
    height:  1.1725*ffem/fem,
    color:  Color(0xff211772),
  ),
),
),
Container(
  // oval16b (0:477)
  margin:  EdgeInsets.fromLTRB(0*fem, 13*fem, 0*fem, 0*fem),
  width:  26*fem,
  height:  26*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
  ],
),
),
Container(
  // autogroupn2q1X4w (2Z9ivPR5FTdjiCKiX9n2q1)
  padding:  EdgeInsets.fromLTRB(24*fem, 32*fem, 24*fem, 34*fem),
  width:  double.infinity,
  decoration:  BoxDecoration (
    color:  Color(0xff211772),
    borderRadius:  BorderRadius.only (
      topLeft:  Radius.circular(48*fem),
      topRight:  Radius.circular(48*fem),
    ),
    boxShadow:  [
      BoxShadow(
        color:  Color(0x33211772),
        offset:  Offset(0*fem, -4*fem),
        blurRadius:  5*fem,
      ),
    ],
  ),
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // everydayBfH (0:439)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 259*fem, 0*fem),
  child:  
Text(
  'Every day',
  style:  TextStyle (
    fontSize:  16*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.0625*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
SizedBox(
  height:  16*fem,
),
Container(
  // group13rmR (0:58)
  width:  double.infinity,
  height:  24*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // monnov17CaP (0:69)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 153*fem, 0*fem),
  child:  
Text(
  'Mon, Nov 17',
  style:  TextStyle (
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // group11KQ7 (0:59)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 18*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // TFR (0:63)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '33',
  style:  TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
Container(
  // ovalnYb (0:62)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // group11copyKoR (0:64)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 23*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // 3zK (0:68)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '24',
  style:  TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // ovalxrP (0:67)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // mostlysunnycopyVrK (0:70)
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
SizedBox(
  height:  16*fem,
),
Container(
  // group13copyQyH (0:117)
  width:  double.infinity,
  height:  24*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // tuenov18Mdd (0:128)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 157*fem, 0*fem),
  child:  
Text(
  'Tue, Nov 18',
  style:  TextStyle (
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // group11srs (0:118)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 18*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // oEj (0:122)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '30',
  style:  TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
Container(
  // oval827 (0:121)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // group11copyf23 (0:123)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 23*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // oe3 (0:127)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '23',
  style:  TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // ovalkJP (0:126)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // cloudsGnX (0:129)
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
SizedBox(
  height:  16*fem,
),
Container(
  // group13copy2B8o (0:144)
  width:  double.infinity,
  height:  24*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // wednov198Jw (0:155)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 153*fem, 0*fem),
  child:  
Text(
  'Wed, Nov 19',
  style:  TextStyle (
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // group11rVq (0:145)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 18*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // bTR (0:149)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '30',
  style:  TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
Container(
  // ovalXM5 (0:148)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // group11copyegb (0:150)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 23*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // nH1 (0:154)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '24',
  style:  TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // ovalKGw (0:153)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // rainylightningFgP (0:156)
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
SizedBox(
  height:  16*fem,
),
Container(
  // group13copy3NW7 (0:174)
  width:  double.infinity,
  height:  24*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // thunov20vXd (0:185)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 156*fem, 0*fem),
  child:  
Text(
  'Thu, Nov 20',
  style: TextStyle (
    
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // group112Km (0:175)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 18*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // ZqV (0:179)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '28',
  style: TextStyle (
  
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
Container(
  // oval64j (0:178)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // group11copyDQF (0:180)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 23*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // ZDD (0:184)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '22',
  style: TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // oval6U3 (0:183)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // rainyBkP (0:186)
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
SizedBox(
  height:  16*fem,
),
Container(
  // group13copy4hij (0:211)
  width:  double.infinity,
  height:  24*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // frinov21SwD (0:222)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 163*fem, 0*fem),
  child:  
Text(
  'Fri, Nov 21',
  style: TextStyle (
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // group11mib (0:212)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 18*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // WgB (0:216)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '28',
  style: TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
Container(
  // ovalSJw (0:215)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // group11copyZPZ (0:217)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 23*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // i1Z (0:221)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '22',
  style: TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // ovaleR1 (0:220)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // rainynGK (0:223)
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
SizedBox(
  height:  16*fem,
),
Container(
  // group13copy5v7d (0:248)
  width:  double.infinity,
  height:  24*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // satnov22GSP (0:259)
  margin:  EdgeInsets.fromLTRB(0*fem, 1*fem, 159*fem, 0*fem),
  child:  
Text(
  'Sat, Nov 22',
  style: TextStyle (
    fontSize:  12*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.4166666667*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // group11yLo (0:249)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 18*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // K9m (0:253)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '31',
  style: TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w500,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffffffff),
  ),
),
),
Container(
  // ovalF3R (0:252)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // group11copynJF (0:254)
  margin:  EdgeInsets.fromLTRB(0*fem, 4*fem, 23*fem, 3*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // jUP (0:258)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 1*fem, 0*fem),
  child:  
Text(
  '23',
  style: TextStyle (
    fontSize:  14*ffem,
    fontWeight:  FontWeight.w400,
    height:  1.2142857143*ffem/fem,
    color:  Color(0xffd8d8d8),
  ),
),
),
Container(
  // ovalsqV (0:257)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  width:  4*fem,
  height:  4*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
Container(
  // mostlysunnycopyPoq (0:260)
  width:  24*fem,
  height:  24*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  width: 24*fem,
  height: 24*fem,
)
),
  ],
),
),
  ],
),
),
  ],
),
),
));}}