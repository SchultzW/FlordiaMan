![image-20200314124620914](C:\Users\wills\AppData\Roaming\Typora\typora-user-images\image-20200314124620914.png)

My two red flags are for Cross-Site Scripting attacks Zap had low confidence with this exploit. The pages that were flagged were the EF login and logout page.  I think this may be a false positive. The best solution for XSS is to use a framework or library, which I have. These pages were created by VS and I *hope* Microsoft could make pages that are not susceptible to XSS attacks.

I also had an orange X-Frame-Options Header not set error which I decided to fix. I added some lines of code to the startup to stop this. 