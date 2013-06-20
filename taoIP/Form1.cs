﻿using IpRanges;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace taoIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initCombList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtjson.Text = "";
            string ip = txtipaddress.Text;
            string jsonstring = GetIPAddressJsonFromTaoBao(ip);
            var Info = JsonConvert.DeserializeObject<Info>(jsonstring);
            txtjson.Text = Router.getProperties<TaoBaoIP>(Info.Data).Replace(",", "\r\n");

        }

        private string GetIPAddressJsonFromTaoBao(string ipaddress)
        {
            String url = string.Format("http://ip.taobao.com/service/getIpInfo.php?ip={0}", ipaddress);
            CredentialCache cache = new CredentialCache();
            return Router.SendRequest(url, Encoding.GetEncoding(936), cache);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtrouterid.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("IP,用户名，密码请填写完整!");
                txtrouterid.Focus();
            }
            else
            {
                string returnstr = Router.RestartRouter(txtrouterid.Text, txtusername.Text, txtpassword.Text);
                label4.Text = returnstr;
            }
        }
        /// <summary>
        /// 天气查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                ListItem info = comboBox1.SelectedItem as ListItem;
                //txtCloud.Text = GetWeatherByCityID(info.ID);
            }
        }

        private weatherinfo GetWeatherByCityID(string cityid)
        {
            string url = String.Format("http://www.weather.com.cn/data/cityinfo/{0}.html", cityid);
            CredentialCache cache = new CredentialCache();
            string jsonstring = Router.SendRequest(url, Encoding.UTF8, cache);

            //weatherinfo Info = (weatherinfo)JsonConvert.DeserializeObject(jsonstring);
            JObject weather = JsonConvert.DeserializeObject(jsonstring) as JObject;
            weatherinfo info = new weatherinfo();

            info.city = weather["weatherinfo"]["city"].ToString();
            info.cityid = weather["weatherinfo"]["cityid"].ToString();
            info.temp1 = weather["weatherinfo"]["temp1"].ToString();
            info.temp2 = weather["weatherinfo"]["temp2"].ToString();
            info.weather = weather["weatherinfo"]["weather"].ToString();
            info.img1 = weather["weatherinfo"]["img1"].ToString();
            info.img2 = weather["weatherinfo"]["img2"].ToString();
            try
            {
                info.ptime = weather["weatherinfo"]["ptime"].ToString();
            }
            catch
            {
                info.ptime = "11:00";
            }
            //return Router.getProperties<weatherinfo>(info).Replace(",", "\r\n");
            return info;
        }

        private List<ListItem> GetCityList()
        {
            List<ListItem> models = new List<ListItem>();
            string list = "北京:101010100朝阳:101010300顺义:101010400怀柔:101010500通州:101010600昌平:101010700延庆:101010800丰台:101010900石景山:101011000大兴:101011100房山:101011200密云:101011300门头沟:101011400平谷:101011500八达岭:101011600佛爷顶:101011700汤河口:101011800密云上甸子:101011900斋堂:101012000霞云岭:101012100北京城区:101012200海淀:101010200天津:101030100宝坻:101030300东丽:101030400西青:101030500北辰:101030600蓟县:101031400汉沽:101030800静海:101030900津南:101031000塘沽:101031100大港:101031200武清:101030200宁河:101030700上海:101020100宝山:101020300嘉定:101020500南汇:101020600浦东:101021300青浦:101020800松江:101020900奉贤:101021000崇明:101021100徐家汇:101021200闵行:101020200金山:101020700石家庄:101090101张家口:101090301承德:101090402唐山:101090501秦皇岛:101091101沧州:101090701衡水:101090801邢台:101090901邯郸:101091001保定:101090201廊坊:101090601郑州:101180101新乡:101180301许昌:101180401平顶山:101180501信阳:101180601南阳:101180701开封:101180801洛阳:101180901商丘:101181001焦作:101181101鹤壁:101181201濮阳:101181301周口:101181401漯河:101181501驻马店:101181601三门峡:101181701济源:101181801安阳:101180201合肥:101220101芜湖:101220301淮南:101220401马鞍山:101220501安庆:101220601宿州:101220701阜阳:101220801亳州:101220901黄山:101221001滁州:101221101淮北:101221201铜陵:101221301宣城:101221401六安:101221501巢湖:101221601池州:101221701蚌埠:101220201杭州:101210101舟山:101211101湖州:101210201嘉兴:101210301金华:101210901绍兴:101210501台州:101210601温州:101210701丽水:101210801衢州:101211001宁波:101210401重庆:101040100合川:101040300南川:101040400江津:101040500万盛:101040600渝北:101040700北碚:101040800巴南:101040900长寿:101041000黔江:101041100万州天城:101041200万州龙宝:101041300涪陵:101041400开县:101041500城口:101041600云阳:101041700巫溪:101041800奉节:101041900巫山:101042000潼南:101042100垫江:101042200梁平:101042300忠县:101042400石柱:101042500大足:101042600荣昌:101042700铜梁:101042800璧山:101042900丰都:101043000武隆:101043100彭水:101043200綦江:101043300酉阳:101043400秀山:101043600沙坪坝:101043700永川:101040200福州:101230101泉州:101230501漳州:101230601龙岩:101230701晋江:101230509南平:101230901厦门:101230201宁德:101230301莆田:101230401三明:101230801兰州:101160101平凉:101160301庆阳:101160401武威:101160501金昌:101160601嘉峪关:101161401酒泉:101160801天水:101160901武都:101161001临夏:101161101合作:101161201白银:101161301定西:101160201张掖:101160701广州:101280101惠州:101280301梅州:101280401汕头:101280501深圳:101280601珠海:101280701佛山:101280800肇庆:101280901湛江:101281001江门:101281101河源:101281201清远:101281301云浮:101281401潮州:101281501东莞:101281601中山:101281701阳江:101281801揭阳:101281901茂名:101282001汕尾:101282101韶关:101280201南宁:101300101柳州:101300301来宾:101300401桂林:101300501梧州:101300601防城港:101301401贵港:101300801玉林:101300901百色:101301001钦州:101301101河池:101301201北海:101301301崇左:101300201贺州:101300701贵阳:101260101安顺:101260301都匀:101260401兴义:101260906铜仁:101260601毕节:101260701六盘水:101260801遵义:101260201凯里:101260501昆明:101290101红河:101290301文山:101290601玉溪:101290701楚雄:101290801普洱:101290901昭通:101291001临沧:101291101怒江:101291201香格里拉:101291301丽江:101291401德宏:101291501景洪:101291601大理:101290201曲靖:101290401保山:101290501呼和浩特:101080101乌海:101080301集宁:101080401通辽:101080501阿拉善左旗:101081201鄂尔多斯:101080701临河:101080801锡林浩特:101080901呼伦贝尔:101081000乌兰浩特:101081101包头:101080201赤峰:101080601南昌:101240101上饶:101240301抚州:101240401宜春:101240501鹰潭:101241101赣州:101240701景德镇:101240801萍乡:101240901新余:101241001九江:101240201吉安:101240601武汉:101200101黄冈:101200501荆州:101200801宜昌:101200901恩施:101201001十堰:101201101神农架:101201201随州:101201301荆门:101201401天门:101201501仙桃:101201601潜江:101201701襄樊:101200201鄂州:101200301孝感:101200401黄石:101200601咸宁:101200701成都:101270101自贡:101270301绵阳:101270401南充:101270501达州:101270601遂宁:101270701广安:101270801巴中:101270901泸州:101271001宜宾:101271101内江:101271201资阳:101271301乐山:101271401眉山:101271501凉山:101271601雅安:101271701甘孜:101271801阿坝:101271901德阳:101272001广元:101272101攀枝花:101270201银川:101170101中卫:101170501固原:101170401石嘴山:101170201吴忠:101170301西宁:101150101黄南:101150301海北:101150801果洛:101150501玉树:101150601海西:101150701海东:101150201海南:101150401济南:101120101潍坊:101120601临沂:101120901菏泽:101121001滨州:101121101东营:101121201威海:101121301枣庄:101121401日照:101121501莱芜:101121601聊城:101121701青岛:101120201淄博:101120301德州:101120401烟台:101120501济宁:101120701泰安:101120801西安:101110101延安:101110300榆林:101110401铜川:101111001商洛:101110601安康:101110701汉中:101110801宝鸡:101110901咸阳:101110200渭南:101110501太原:101100101临汾:101100701运城:101100801朔州:101100901忻州:101101001长治:101100501大同:101100201阳泉:101100301晋中:101100401晋城:101100601吕梁:101101100乌鲁木齐:101130101石河子:101130301昌吉:101130401吐鲁番:101130501库尔勒:101130601阿拉尔:101130701阿克苏:101130801喀什:101130901伊宁:101131001塔城:101131101哈密:101131201和田:101131301阿勒泰:101131401阿图什:101131501博乐:101131601克拉玛依:101130201拉萨:101140101山南:101140301阿里:101140701昌都:101140501那曲:101140601日喀则:101140201林芝:101140401台北县:101340101高雄:101340201台中:101340401海口:101310101三亚:101310201东方:101310202临高:101310203澄迈:101310204儋州:101310205昌江:101310206白沙:101310207琼中:101310208定安:101310209屯昌:101310210琼海:101310211文昌:101310212保亭:101310214万宁:101310215陵水:101310216西沙:101310217南沙岛:101310220乐东:101310221五指山:101310222琼山:101310102长沙:101250101株洲:101250301衡阳:101250401郴州:101250501常德:101250601益阳:101250700娄底:101250801邵阳:101250901岳阳:101251001张家界:101251101怀化:101251201黔阳:101251301永州:101251401吉首:101251501湘潭:101250201南京:101190101镇江:101190301苏州:101190401南通:101190501扬州:101190601宿迁:101191301徐州:101190801淮安:101190901连云港:101191001常州:101191101泰州:101191201无锡:101190201盐城:101190701哈尔滨:101050101牡丹江:101050301佳木斯:101050401绥化:101050501黑河:101050601双鸭山:101051301伊春:101050801大庆:101050901七台河:101051002鸡西:101051101鹤岗:101051201齐齐哈尔:101050201大兴安岭:101050701长春:101060101延吉:101060301四平:101060401白山:101060901白城:101060601辽源:101060701松原:101060801吉林:101060201通化:101060501沈阳:101070101鞍山:101070301抚顺:101070401本溪:101070501丹东:101070601葫芦岛:101071401营口:101070801阜新:101070901辽阳:101071001铁岭:101071101朝阳:101071201盘锦:101071301大连:101070201锦州:101070701 ";

            string patten = @"([\S\s]*?):(\d{9})";

            Regex regUrl = new Regex(patten, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection matches = regUrl.Matches(list);
            foreach (var q in matches)
            {
                models.Add(new ListItem(q.ToString().Split(':')[1], q.ToString().Split(':')[0]));
            }
            return models;
            
        }

        private void initCombList()
        {
            //comboBox1.Items.AddRange(GetCityList().ToArray());
            foreach (ListItem model in GetCityList())
            {
                comboBox1.Items.Add(model);
            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                ListItem info = comboBox1.SelectedItem as ListItem;

                weatherdisplay1.weatherinit(GetWeatherByCityID(info.ID));
            }
        }


        private string RegexReplace(string source, string patten)
        {
            Regex r = new Regex(patten);
            Match m = r.Match(source);
            return m.Result("$1");
        }
    }
    public class ListItem
    {
        private string id = string.Empty;
        private string name = string.Empty;

        public ListItem(string sid, string sname)
        {
            id = sid;
            name = sname;
        }
        public override string ToString()
        {
            return this.name;
        }
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        } 
    }


    public class citymodel
    {
        public string cityname { get; set; }
        public string cityid { get; set; }
    }
    public class weatherinfo
    {
        public string city { get; set; }
        public string cityid { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public string weather { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string ptime { get; set; }
    }

    public class TaoBaoIP
    {
        public string isp_id { get; set; }

        public string county_id { get; set; }

        public string city_id { get; set; }

        public string region_id { get; set; }

        public string area_id { get; set; }

        public string country_id { get; set; }

        public string isp { get; set; }

        public string county { get; set; }

        public string city { get; set; }

        public string region { get; set; }

        public string area { get; set; }

        public string country { get; set; }

        public string ip { get; set; }
    }
    public class Info
    {
        public int Code { get; set; }
        public TaoBaoIP Data { get; set; }
    }

}
