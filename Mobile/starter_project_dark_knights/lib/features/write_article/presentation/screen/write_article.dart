import 'package:flutter/material.dart';
import '../widgets/add_tags.dart';
import '../widgets/add_article_content.dart';
import '../widgets/add_subtitle.dart';
import '../widgets/add_title.dart';
import '../widgets/publish_button.dart';
import '../widgets/title_bar.dart';

void main() {
  runApp(const WriteArticle());
}

class WriteArticle extends StatelessWidget {
  const WriteArticle({super.key});
  

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'write Article',
      home:  Scaffold(
        body: SafeArea(
          child: ListView(
            shrinkWrap: true,
            children: [
              TitleBar(),
              const AddTitle(),
              const AddSubtitle(),
              TagSelector(),
              const AddArticleContent(),
              const PublishButton(),
            ],
          ),
        ),
        
      ),
    );
  }
}
