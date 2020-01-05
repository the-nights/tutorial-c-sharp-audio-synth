using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Synth
{
    public partial class BasicSynth : Form
    {
        private const int SAMPLE_RATE = 44100;
        private const short BITS_PER_SAMPLE = 16;

        public BasicSynth()
        {
            InitializeComponent();
        }

        private void BasicSynth_KeyDown(object sender, KeyEventArgs e)
        {
            IEnumerable<OscillatorController> oscilators = this.Controls.OfType<OscillatorController>().Where(o => o.On);
            int oscilatorsCount = oscilators.Count();

            Random random = new Random((int)DateTime.Now.Ticks);
            float frequency=440f;
            switch (e.KeyCode)
            {
                case Keys.Z:
                    frequency = 65.4f; // C2
                break;
                case Keys.X:
                    frequency = 138.59f; // C3
                break;
                case Keys.C:
                    frequency = 261.61f; // C4
                break;
                case Keys.V:
                    frequency = 523.25f; // C5
                break;
                case Keys.B:
                    frequency = 1046.5f; // C6
                break;
                case Keys.N:
                    frequency = 2093.5f; // C7
                break;
                case Keys.M:
                    frequency = 4186.01f; // C8
                break;
                    
                   
            }


            short[] wave = new short[SAMPLE_RATE];
            byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
            short tempSample;
            int samplePerWaveLength = (int)(SAMPLE_RATE / frequency);
            short ampStep = (short)((short.MaxValue * 2) / samplePerWaveLength);            

            // switching oscolator type
            foreach(OscillatorController oscillatorController in oscilators)
            {
                switch(oscillatorController.WaveForm)
                {
                    case WaveForm.Sine:
                        // generating sin wave.
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i)/ oscilatorsCount);
                        }
                        break;
                    case WaveForm.Square:
                        // generating square wave.
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * frequency) / SAMPLE_RATE * i)) / oscilatorsCount);
                        }
                        break;
                    case WaveForm.Saw:
                        // generating sqw wave.
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            tempSample = -short.MaxValue;
                            for (int j = 0; j < samplePerWaveLength && j<SAMPLE_RATE; j++)
                            {
                                tempSample += ampStep;
                                wave[(i++)%SAMPLE_RATE] += Convert.ToInt16(tempSample / oscilatorsCount);
                            }
                            i--;
                        }
                        break;
                    case WaveForm.Triangle:
                        // generating triangle wave.
                        tempSample = -short.MaxValue;
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            if(Math.Abs(tempSample+ampStep)>short.MaxValue)
                            {
                                ampStep = (short)-ampStep;
                            }
                            tempSample += ampStep;
                            wave[i] += Convert.ToInt16(tempSample / oscilatorsCount);
                        }
                        break;
                    case WaveForm.Noise:
                        // generating noise wave.
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(random.Next(-short.MaxValue,short.MaxValue) / oscilatorsCount);
                        }
                        break;
                }
            }






            // make a binary copy of the wave 
            Buffer.BlockCopy(wave, 0, binaryWave, 0, SAMPLE_RATE * sizeof(short));


            // make the sound wave using microsoft build in Wave format 
            using (MemoryStream memoryStream = new MemoryStream())
                using(BinaryWriter binaryWriter = new BinaryWriter(memoryStream) )
            {
                // Crappy Wave file header. replace later but keep in case of needing.

                // Code explination http://soundfile.sapp.org/doc/WaveFormat/
                short blockAlign = BITS_PER_SAMPLE / 8; // what was this used for again ? 
                int subChunkTwoSize = SAMPLE_RATE * blockAlign;
                binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                binaryWriter.Write(36+subChunkTwoSize);
                binaryWriter.Write(new[] { 'W', 'A', 'V', 'E','f','m','t',' '});
                binaryWriter.Write(16);
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)1);
                binaryWriter.Write(SAMPLE_RATE);
                binaryWriter.Write(SAMPLE_RATE*blockAlign);
                binaryWriter.Write(blockAlign);
                binaryWriter.Write(BITS_PER_SAMPLE);
                binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
                binaryWriter.Write(subChunkTwoSize); 
                binaryWriter.Write(binaryWave);
                memoryStream.Position = 0;
                new SoundPlayer(memoryStream).Play();
            }
        }
    }
}
